using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository
    {
        public void Add(Users entity)
        {
            SomethingEntities ctx = new SomethingEntities();
            entity.IsDeleted = false;
            ctx.Set<Users>().Add(entity);
            ctx.SaveChanges();
        }

        public List<Users> List()
        {
            List<Users> liste = new List<Users>();
            SomethingEntities ctx = new SomethingEntities();
            liste = ctx.Set<Users>().ToList();
            return liste;
        }

        public Users List(int id)
        {
            Users user = new Users();
            SomethingEntities ctx = new SomethingEntities();
            user = ctx.Set<Users>().Where(c => c.Id == id).FirstOrDefault();
            return user;
        }

        public void Delete(int Id)
        {
            SomethingEntities ctx = new SomethingEntities();
            Users usr = ctx.Set<Users>().Where(c => c.Id == Id).FirstOrDefault();
            ctx.Set<Users>().Remove(usr);
            ctx.SaveChanges();
        }

        public void Edit(int Id)
        {
            SomethingEntities ctx = new SomethingEntities();
            Users usr = ctx.Set<Users>().Where(c => c.Id == Id).FirstOrDefault();
            ctx.Set<Users>().Remove(usr);
            ctx.SaveChanges();
        }
    }
}
