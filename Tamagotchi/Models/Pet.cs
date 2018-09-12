using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    private string _petName;
    private int _id;
    private int _attention;//not attn = death;
    private int _hunger; //t/f if t=feed;
    private int _sleep; //t/f if t=sleep;
    private bool _death; //t/f if <sleep||>hungry ==0, t=death;

    private static List<Pet> _instances = new List<Pet> {};

    public Pet(string petName)
    {
      _petName = petName;
      _instances.Add(this);
      _id = _instances.Count;
      _hunger = 0;
      _sleep = 100;
      _attention = 100;
      _death= false;
    }
    public void SetDeath (bool passAway)
    {
      _death = passAway;
    }

    public bool GetDeath()
    {
      return _death;
    }
    public void SetPetName(string petName)
    {
      _petName = petName;
    }
    public string GetPetName()
    {
      return _petName;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetAttention(int attention)
    {
      _attention = attention;
    }
    public int GetAttention()
    {
      return _attention;
    }

    public void SetHunger(int hunger)
    {
      _hunger = hunger;
    }
    public int GetHunger()
    {
      return _hunger;
    }

    public void SetSleep(int sleep)
    {
      _sleep = sleep;
    }
    public int GetSleep()
    {
      return _sleep;
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void IncreaseHunger() //=100,death;
    {
      this.SetHunger(this.GetHunger() + 10);
    }
    public void DecreaseSleep() //= 0,death;
    {
      this.SetSleep(this.GetSleep() - 10);
    }
    public void DecreaseAttention() //= 0,death;
    {
      this.SetAttention(this.GetAttention() - 10);
    }

    public static void Aging(Pet thisPet)
    {
      thisPet.IncreaseHunger();
      thisPet.DecreaseSleep();
      thisPet.DecreaseAttention();
    }

  //Pet.Aging(newPet);
  }
}
