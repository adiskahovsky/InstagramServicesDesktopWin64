using InstaSharper.API;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using MailWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    public interface IInstagram
    {
        IInstaApi InstaApi { get; }
        Mail mail { get; set; }









        string UserName { get; set; }



        string Password { get; set; }

      //  Task<IResult<InstaLoginResult>> LoginWithNumber();
        Task<IResult<InstaLoginResult>> Login();
        Task<IResult<bool>> LikePost(string uri);
        Task<IResult<bool>> UnLikePost(string uri);
        Task<IResult<InstaComment>> CommentPost(string uri);
        Task<IResult<bool>> UnCommentPost(string uri);
        Task<IResult<InstaFriendshipStatus>> Subscribe(string uri);
        Task<IResult<InstaFriendshipStatus>> UnSubscribe(string uri);




    }
}
