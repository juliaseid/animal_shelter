using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
    public char Sex { get; set; }
    public int Age { get; set; }

    public string Breed { get; set; }
    public DateTime AdmitDate { get; set; }
    public bool SpecialNeeds { get; set; }

    private static List<Animal> _inventory = new List<Animal> { };

    public Animal(string name, string type, char sex, int age, string breed, DateTime admitDate, bool specialNeeds)
    {
      Name = name;
      Sex = sex;
      Age = age;
      Breed = breed;
      AdmitDate = admitDate;
      SpecialNeeds = specialNeeds;
      _inventory.Add(this);
      AnimalId = _inventory.Count;
    }
  }
}