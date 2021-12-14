using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LjubavNaPmfu.Baza;
using LjubavNaPmfu.Mappers;

namespace LjubavNaPmfu.Repositories
{
    public class KorisnikRepository
    {
        private readonly ljubavContext _dbContext;

        public KorisnikRepository(ljubavContext db)
        {
            _dbContext = db;
        }

        public void Novi(Models.Korisnik korisnik_)
        {
            var DbKorisnik = KorisnikMapper.ToDatabase(korisnik_);
            _dbContext.Korisnik.Add(DbKorisnik);
            _dbContext.SaveChanges();
        }

        public void Dodaj(Models.KorisnikHobiji k)
        {
            var DbKorisnikHobiji = KorisnikHobijiMapper.ToDataBase(k);
            var n = _dbContext.KorisnikHobiji.Where(x => (x.IdP.Equals(DbKorisnikHobiji.IdP)) && (x.IdH.Equals(DbKorisnikHobiji.IdH))).SingleOrDefault();
            _dbContext.KorisnikHobiji.Add(DbKorisnikHobiji);
            _dbContext.SaveChanges();
        }

        public bool PostojiHobi(int? idp,int idh)
        {
            var Dbkorisnikhobiji = _dbContext.KorisnikHobiji.Where(x => (x.IdP.Equals(idp)) && (x.IdH.Equals(idh))).FirstOrDefault();
            if (Dbkorisnikhobiji == null)
            {
                return false;
            }
            else
                return true;
        }

        public bool Postoji(string username)
        {
            var dbKor = _dbContext.Korisnik.Where(x => x.Username.Equals(username)).FirstOrDefault();
            return dbKor != null;
        }
        public bool Hobiji(int? id)
        {
            var dbHobi = _dbContext.KorisnikHobiji.Where(x => (x.IdP.Equals(id))).FirstOrDefault();
            if(dbHobi == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Models.Korisnik LoginKorisnik(string username, string pasword)
        {
            var dbKorisnik = _dbContext.Korisnik.Where(x => (x.Username.Equals(username) && x.Lozinka.Equals(pasword))).FirstOrDefault();
            if (dbKorisnik == null)
                return null;
            return KorisnikMapper.FromDatabase(dbKorisnik);
        }
    }
}
