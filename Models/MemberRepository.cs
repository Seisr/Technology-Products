using WebApp.Services;

namespace WebApp.Models;

public class MemberRepository : BaseRepository
{
    public MemberRepository(StoreContext context) : base(context) { }

    public int Add(RegisterModel obj)
    {
        context.Members.Add(new Member
        {
            Id = Guid.NewGuid().ToString().Replace("-", string.Empty),
            GivenName = obj.GivenName,
            Surname = obj.Surname,
            Email = obj.Email,
            Password = Helper.Hash(obj.Password),
            RegisterDate = DateTime.Now,
            LoginDate = DateTime.Now
        });
        return context.SaveChanges();
    }

}