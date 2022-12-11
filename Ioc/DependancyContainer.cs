using Core.Convertors;
using Core.IServices;
using Core.Services;
using Data.Repositories;
using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc
{
    public class DependancyContainer
    {
        public static void RegisterService(IServiceCollection service)
        {
            #region CoreLayer
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IViewRenderService, RenderViewToString>();
            service.AddTransient<IUserPanelService, UserPanelService>();
            service.AddTransient<ICourseGroupService, CourseGroupService>();
            service.AddTransient<IUserAdminService, UserAdminService>();
            service.AddTransient<ICourseService, CourseService>();
            service.AddTransient<IAdminMessageService, AdminMessageService>();
            service.AddTransient<IEpisodeService, EpisodeService>();
            service.AddTransient<ICommentService, CommentService>();
            service.AddTransient<IBuyCourseService, BuyCourseService>();
            service.AddTransient<IPermissionService, PermissionService>();
            service.AddTransient<IIndexService, IndexService>();
            service.AddTransient<IAdminDashboardService, AdminDashboardService>();
            service.AddTransient<IRateCourseService, RateCourseService>();

            #endregion
            
            #region DataLayer
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IMessageRepository, MessageRepository>();
            service.AddTransient<IWalletRepository, WalletRepository>();
            service.AddTransient<ICourseGroupRepository, CourseGroupRepository>();
            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<IUserRoleRepository, UserRoleRepository>();
            service.AddTransient<ICourseRepository, CourseRepository>();
            service.AddTransient<ICourseToGroupRepository, CourseToGroupRepository>();
            service.AddTransient<IAdminMessageToUserRepository, AdminMessageToUserRepository>();
            service.AddTransient<IAdminMessageRepository, AdminMessageRepository>();
            service.AddTransient<IEpisodeRepository, EpisodeRepository>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<IReplyCommentRepository, ReplyCommentRepository>();
            service.AddTransient<ICartRepository, CartRepository>();
            service.AddTransient<ICartDetailRepository, CartDetailRepository>();
            service.AddTransient<IUserToCourseRepository, UserToCourseRepository>();
            service.AddTransient<IDirectBuyRepository, DirectBuyRepository>();
            service.AddTransient<IRateCourseRepository, RateCourseRepository>();
            service.AddTransient<ISiteRateRepository, SiteRateRepository>();
            #endregion


        }

    }
}
