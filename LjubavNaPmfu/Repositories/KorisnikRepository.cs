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
            var n = _dbContext.KorisnikHobiji.Where(x => (x.Idk.Equals(DbKorisnikHobiji.Idk)) && (x.Idh.Equals(DbKorisnikHobiji.Idh))).SingleOrDefault();
            _dbContext.KorisnikHobiji.Add(DbKorisnikHobiji);
            _dbContext.SaveChanges();
        }

        public bool PostojiHobi(int? idp,int idh)
        {
            var Dbkorisnikhobiji = _dbContext.KorisnikHobiji.Where(x => (x.Idk.Equals(idp)) && (x.Idh.Equals(idh))).FirstOrDefault();
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
            var dbHobi = _dbContext.KorisnikHobiji.Where(x => (x.Idk.Equals(id))).FirstOrDefault();
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

        public void Matchaj(Models.Match m)
        {
            var dbMatch = MatchMapper.ToDatabase(m);
            _dbContext.Match.Add(dbMatch);
            _dbContext.SaveChanges();
        }

        public bool Matchan(int prvi,int drugi)
        {
            var dbMatch = _dbContext.Match.Where(x => x.IdPrvi.Equals(prvi) && x.IdDrugi.Equals(drugi)).FirstOrDefault();

            if(dbMatch == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Odbij(Models.Odbijeni o)
        {
            var dbOdbij = OdbijeniMapper.ToDatabase(o);
            _dbContext.Odbijeni.Add(dbOdbij);
            _dbContext.SaveChanges();
        }
        public bool Odbijen(int prvi,int drugi)
        {
            var dbOdbij=_dbContext.Odbijeni.Where(x=> x.IdPrvi.Equals(prvi) && x.IdDrugi.Equals(drugi)).FirstOrDefault();
            if (dbOdbij == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Blokaj(Models.Blokirani b)
        {
            var dbBLokaj = BlokiraniMapper.ToDatabase(b);
            _dbContext.Blokirani.Add(dbBLokaj);
            _dbContext.SaveChanges();
        }
        public bool Blokan(int prvi, int drugi)
        {
            var dbBlokan = _dbContext.Odbijeni.Where(x => x.IdPrvi.Equals(prvi) && x.IdDrugi.Equals(drugi)).FirstOrDefault();
            if (dbBlokan == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
