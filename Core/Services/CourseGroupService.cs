using Core.Convertors;
using Core.Generators;
using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CourseGroupService : ICourseGroupService
    {
        private ICourseGroupRepository _courseGroupRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private ICourseToGroupRepository _courseToGroupRepository;
        public CourseGroupService(ICourseGroupRepository courseGroupRepository,
            IHttpContextAccessor httpContextAccessor, ICourseToGroupRepository courseToGroupRepository)
        {
            _courseGroupRepository = courseGroupRepository;
            _httpContextAccessor = httpContextAccessor;
            _courseToGroupRepository = courseToGroupRepository;
        }



        public void AddCourseGroup(CreateCourseGroupViewModel createCourseGroup)
        {
            string groupTitle = createCourseGroup.GroupTitle;
            string[] subGroupsTitle = createCourseGroup.SubGroupsTitle.Split('-');

            string mainGroupImageName = NameGenerator.GenerateUniqeCode() +
                Path.GetExtension(createCourseGroup.MainGroupImage.FileName);
            #region Save MainGroup Image in 2 size
            string saveImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/MainGroupImg/orginalImage", mainGroupImageName);

            using (var stream = new FileStream(saveImagePath, FileMode.Create))
            {
                createCourseGroup.MainGroupImage.CopyTo(stream);
            }

            //finger image
            string fingerImg = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/MainGroupImg/fingerImage", mainGroupImageName);
            ResizeImage.Image_resize(saveImagePath, fingerImg, 250);

            #endregion

            CourseGroup courseGroup = new CourseGroup()
            {
                GroupTitle = groupTitle,
                ParenetId = null,
                MainGroupImage = mainGroupImageName,
            };

            _courseGroupRepository.AddEntity(courseGroup);
            if (subGroupsTitle != null)
            {
                foreach (var sub in subGroupsTitle)
                {
                    _courseGroupRepository.AddEntity(new CourseGroup()
                    {
                        GroupTitle = sub,
                        ParenetId = courseGroup.GroupId
                    });
                }
            }

        }

        public void EditCourseGroup(EditCourseGroupViewModel editCourseGroup)
        {
            string newMainGroupImageName = editCourseGroup.previousImageName;
            #region Save New MainGroup Image
            if (editCourseGroup.NewMainGroupImage != null)
            {
                //delete precious image
                if (editCourseGroup.previousImageName != null)
                {
                    //delete orginal img
                    string deleteOrginalImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/MainGroupImg/orginalImage", editCourseGroup.previousImageName);
                    System.IO.File.Delete(deleteOrginalImgPath);

                    //delete finger img
                    string deleteFingerImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/MainGroupImg/fingerImage", editCourseGroup.previousImageName);
                    System.IO.File.Delete(deleteFingerImgPath);

                }
                //save new chosen image
                newMainGroupImageName = NameGenerator.GenerateUniqeCode() +
                    Path.GetExtension(editCourseGroup.NewMainGroupImage.FileName);

                string newOrginalImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/MainGroupImg/orginalImage", newMainGroupImageName);
                using (var stream = new FileStream(newOrginalImgPath, FileMode.Create))
                {
                    editCourseGroup.NewMainGroupImage.CopyTo(stream);
                }
                string newFingerImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/MainGroupImg/fingerImage", newMainGroupImageName);
                ResizeImage.Image_resize(newOrginalImgPath, newFingerImgPath, 250);


                CourseGroup mainGroup = _courseGroupRepository.Get(g =>
                g.GroupId == editCourseGroup.MainGroupId).Single();
                mainGroup.MainGroupImage = newMainGroupImageName;

                _courseGroupRepository.UpdateEntity(mainGroup);
            }

            #endregion

            CourseGroup previousMainGroup = _courseGroupRepository.Get(g =>
            g.GroupId == editCourseGroup.MainGroupId).Single();

            #region edit MainGroup If its Changed
            if (previousMainGroup.GroupTitle != editCourseGroup.GroupTitle)
            {
                CourseGroup mainGroup = new CourseGroup()
                {
                    GroupId = editCourseGroup.MainGroupId,
                    GroupTitle = editCourseGroup.GroupTitle,
                    ParenetId = null,
                    MainGroupImage = newMainGroupImageName
                };
                _courseGroupRepository.UpdateEntity(mainGroup);
            }

            #endregion

            List<CourseGroup> previousSubGroupsList = _courseGroupRepository.Get(g => 
            g.ParenetId == editCourseGroup.MainGroupId).ToList();
            List<string> previousSubGroupsNameList = previousSubGroupsList.Select(c=> c.GroupTitle).ToList();

            string previousSubGroupsString = string.Join("-", previousSubGroupsNameList);

            #region Edit SubGroups If changed
            if (previousSubGroupsString != editCourseGroup.SubGroupsTitle)
            {
                foreach (var subGroup in previousSubGroupsList)
                {
                    #region Remove CourseToGroups
                    var courseToGroups = _courseToGroupRepository.Get(cg =>
                                           cg.CourseGroupId == subGroup.GroupId).ToList();
                    foreach (var courseToGroup in courseToGroups)
                    {
                        courseToGroup.CourseGroupId = editCourseGroup.MainGroupId;
                        _courseToGroupRepository.UpdateEntity(courseToGroup);
                    }
                    #endregion

                    _courseGroupRepository.Delete(subGroup);
                }
                string[] editSubGroups = editCourseGroup.SubGroupsTitle.Split('-');
                foreach (var sub in editSubGroups)
                {
                    _courseGroupRepository.AddEntity(new CourseGroup()
                    {
                        GroupTitle = sub,
                        ParenetId = editCourseGroup.MainGroupId

                    });
                }

            }

            #endregion

        }

        public List<ShowCourseGroupsViewModel> GetAllCourseGroups()
        {
            return _courseGroupRepository.Get().Select(g => new ShowCourseGroupsViewModel()
            {
                GroupId = g.GroupId,
                GroupTitle = g.GroupTitle,
                ParentId = g.ParenetId,
                MainGroupImageName = g.MainGroupImage

            }).ToList();
        }

        public List<ShowGroupsViewModel> GetAllGroups()
        {
            return _courseGroupRepository.Get().Select(g => new ShowGroupsViewModel()
            {
                GroupTitle = g.GroupTitle,
                ParrentId = g.ParenetId,
                GroupId = g.GroupId,
                CourseCount = g.CourseToGroups.Count()
            }).ToList();
        }

        public EditCourseGroupViewModel GetGroupForEdit(int mainGroupId)
        {

            var mainGroup = _courseGroupRepository.GetEntity(g => g.GroupId == mainGroupId);
            var subGroups = _courseGroupRepository.Get(g => g.ParenetId == mainGroupId);
            List<string> subGroupTitles = new List<string>();
            foreach (var sub in subGroups)
            {
                subGroupTitles.Add(sub.GroupTitle);
            }
            string subTitles = string.Join("-", subGroupTitles);
            return new EditCourseGroupViewModel()
            {
                MainGroupId = mainGroupId,
                GroupTitle = mainGroup.GroupTitle,
                SubGroupsTitle = subTitles,
                previousImageName = mainGroup.MainGroupImage
            };
        }

        public List<ShowMainGroupsForIndex> GetMainGroups()
        {
            return _courseGroupRepository.Get(g => g.ParenetId == null).Select(g => new ShowMainGroupsForIndex()
            {
                //ImageName = ,
                MainGroupId = g.GroupId,
                MainGtoupTitle = g.GroupTitle
            }).ToList();
        }
    }
}

