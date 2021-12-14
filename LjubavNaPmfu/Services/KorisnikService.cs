using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using LjubavNaPmfu.Repositories;
using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Services
{
    public class KorisnikService
    {

        public KorisnikRepository _KorisnikRepository;

        public KorisnikService(KorisnikRepository re)
        {
            _KorisnikRepository = re;
        }
        public void Novi(Korisnik k_)
        {
            _KorisnikRepository.Novi(k_);
        }

        public Models.Korisnik VerifyKorisnik(string username, string loz, string loz2,string ime,string dob,string omeni, string mob)
        {
            if (loz == null || loz2 == null)
                return null;
            if (username.Length <= 1 || loz != loz2 || loz.Length < 5)
                return null;

            if (!_KorisnikRepository.Postoji(username))
                return new Models.Korisnik(null,username, loz,"korisnik",ime,int.Parse(dob),omeni,mob);
            return null;
        }

        public Models.Korisnik LoginKorisnik(string username, string lozinka)
        {
            return _KorisnikRepository.LoginKorisnik(username, lozinka);
        }

        public void Dodaj(Models.KorisnikHobiji k)
        {
            _KorisnikRepository.Dodaj(k);
        }

        public bool PostojiHobi(int? idp,int idh)
        {
            return _KorisnikRepository.PostojiHobi(idp, idh);
        }
        public bool Hobijii(int? id)
        {
            return _KorisnikRepository.Hobiji(id);
        }
    }
}
