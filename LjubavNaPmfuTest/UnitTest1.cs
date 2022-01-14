using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.AspNetCore.Http;
using LjubavNaPmfu.Services;
using LjubavNaPmfu.Baza;
using LjubavNaPmfu.Models;
using LjubavNaPmfu.Mappers;
using LjubavNaPmfu.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LjubavNaPmfuTest
{
    [TestClass]
    public class UnitTestovi
    {
        [TestMethod]
        public void TestChat()
        {
            HobijiController controller = new HobijiController(null, null);
            ViewResult result = controller.Chat() as ViewResult;

            Assert.AreEqual("Chat",result.ViewName);

        }
        [TestMethod]
        public void TestProfil()
        {
            HobijiController controller = new HobijiController(null, null);
            ViewResult result = controller.Profil(0).Result as ViewResult;

            Assert.AreEqual("Error2", result.ViewName);
        }
        
        [TestMethod]
        public void TestRegister()
        {
            KorisnikService ks = new KorisnikService(null);
            var result = ks.VerifyKorisnik("", "123456", "123456", "Ana", "21", "Nesto", "mobitel", 2);

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestRegister2()
        {
            KorisnikService ks = new KorisnikService(null);
            var result = ks.VerifyKorisnik("aanic", "123456", "124526", "Ana", "21", "Nesto", "mobitel", 2);

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestRegister3()
        {
            KorisnikService ks = new KorisnikService(null);
            var result = ks.VerifyKorisnik("aanic", "1234", "1234", "Ana", "21", "Nesto", "mobitel", 2);

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestMatchkMapper()
        {
            LjubavNaPmfu.Models.Match match = new LjubavNaPmfu.Models.Match(1, 2);
            LjubavNaPmfu.Baza.Match result = MatchMapper.ToDatabase(match);
            LjubavNaPmfu.Baza.Match expected = new LjubavNaPmfu.Baza.Match
            {
                IdPrvi = match.id1,
                IdDrugi = match.id2
            };

            Assert.AreEqual(expected.IdPrvi, result.IdPrvi);
        }
        [TestMethod]
        public void TestMatchkMapper2()
        {
            LjubavNaPmfu.Models.Match match = new LjubavNaPmfu.Models.Match(1, 2);
            LjubavNaPmfu.Baza.Match result = MatchMapper.ToDatabase(match);
            LjubavNaPmfu.Baza.Match expected = new LjubavNaPmfu.Baza.Match
            {
                IdPrvi = match.id1,
                IdDrugi = match.id2
            };

            Assert.AreEqual(expected.IdDrugi, result.IdDrugi);
        }
        [TestMethod]
        public void TestKorisnikMapper()
        {
            LjubavNaPmfu.Models.Korisnik korisnik = new LjubavNaPmfu.Models.Korisnik(100, "user", "lozinka", "korisnik", "Lucija", 21, "Lucija Dumancic", "mobitel", 1);
            LjubavNaPmfu.Baza.Korisnik result = KorisnikMapper.ToDatabase(korisnik);
            LjubavNaPmfu.Baza.Korisnik expected = new LjubavNaPmfu.Baza.Korisnik
            {
                Username = korisnik.username,
            };

            Assert.AreEqual(expected.Username, result.Username);

        }
        [TestMethod]
        public void TestKorisnikMapper2()
        {
            LjubavNaPmfu.Models.Korisnik korisnik = new LjubavNaPmfu.Models.Korisnik(100, "user", "lozinka", "korisnik", "Lucija", 21, "Lucija Dumancic", "mobitel", 1);
            LjubavNaPmfu.Baza.Korisnik result = KorisnikMapper.ToDatabase(korisnik);
            
            Assert.AreEqual("Lucija Dumancic", result.Omeni);

        }

        [TestMethod]
        public void TestViewbag()
        {
            HomeController controller = new HomeController(null, null,null);

            ViewResult result = controller.Error2() as ViewResult;

            Assert.AreEqual("Error 404", result.ViewData["poruka"]);

        }
        

    }
}
