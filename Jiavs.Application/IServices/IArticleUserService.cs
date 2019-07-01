using Jiavs.Infrastructure.DTO;

namespace Jiavs.Application.IServices
{
    public interface IArticleUserService
    {
        /// <summary>
        /// 创建文章用户
        /// </summary>
        /// <param name="userDto"></param>
        bool Create(ArticleUserDto userDto);

        /// <summary>
        /// 删除文章用户
        /// </summary>
        /// <param name="id"></param>
        bool Delete(uint id);

        /// <summary>
        /// 更新文章用户信息
        /// </summary>
        /// <param name="userDto"></param>
        bool Update(ArticleUserDto userDto);
    }
}