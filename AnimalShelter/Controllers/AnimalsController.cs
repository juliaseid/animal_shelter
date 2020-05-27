using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      // List<Animal> animals = from a in _db.Animals 
      // select a;

      // animals = animals.OrderByDescending(a => a.AdmitDate);

      List<Animal> model = _db.Animals.ToList();

      return View(model);
    }

    // public ViewResult Index()
    // {
    // return View(_db.Animals.ToList());
    // }

    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      if (ModelState.IsValid)
      {
        _db.Animals.Add(animal);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return View(animal);
      }
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }
  }
}