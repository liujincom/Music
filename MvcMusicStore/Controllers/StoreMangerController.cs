using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MvcMusicStore.Models;
using System.Data.Entity;
using System.Data.EntityModel;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class StoreMangerController : Controller
    {
        //
        // GET: /StoreManger/
        MvcMusicStore.Models.MusicStoreEntities storeDB
    = new MvcMusicStore.Models.MusicStoreEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {

            var albums = storeDB.Albums.Include("Genre").Include("Artist");

            return View(albums.ToList());


        }



























        //
        // GET: /StoreManger/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

            return View(album);

        }
        //public ViewResult Details(int id)
        //{

        //    MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

        //    return View(album);

        //}
























        //
        // GET: /StoreManger/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");

            return View();
        }

        //
        // POST: /StoreManger/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {



            if (ModelState.IsValid)
            {
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View(album);

            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /StoreManger/Edit/5

        public ActionResult Edit(int id)
        {
            

    Album album = storeDB.Albums.Find(id);

    ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);

    ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);

    return this.View(album);




            //MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

            //return View(album);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);


            //try
            //{

            //    // TODO: Add update logic here
            //    MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

            //    if (this.TryUpdateModel<MvcMusicStore.Models.Album>(album))
            //    {

            //        return RedirectToAction("Index");

            //    }

            //    return View();

            //}

            //catch
            //{

            //    return View();

            //}

        }


        //
        // GET: /StoreManger/Delete/5
     
        public ActionResult Delete(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);


        }

        //
        // POST: /StoreManger/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = storeDB.Albums.Find(id);

            storeDB.Albums.Remove(album);

            storeDB.SaveChanges();

            return RedirectToAction("Index");	









            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}


