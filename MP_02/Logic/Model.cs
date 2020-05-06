using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


/**
  ******************
  * @author F0urth *
  ******************
  * @date - 5/6/2020 6:11:13 PM *
  ******************
**/

namespace MP_02.Logic
{
    public class Actor
    {
        public string Pesel { get; }
        public string Name { get; }
        public ISet<Movie> ApperedInMovies { get; }
        public Actor(string name, string pesel)
        {
            Name = name;
            Pesel = pesel;
            ApperedInMovies = new HashSet<Movie>();
        }
    }

    public class Movie
    {
        public ISet<Actor> ApperdeActors { get; }
        public string Name { get; }
        public Movie(string name)
        {
            Name = name;
            ApperdeActors = new HashSet<Actor>();
        }
    }
    
    public class Addvertisment
    {
        public string CompanyOrganizing { get; }
        public Addvertisment(string companyOrganizing) => CompanyOrganizing = companyOrganizing;
    }

    public class Theater
    {
        public Dictionary<string, Actor> ActorsQualif { get; }
        public string Localization { get; }
        public string Name { get; set; }

        public Actor this[string pesel]
        {
            get => ActorsQualif[pesel];
            set 
            {
                if (!ActorsQualif.ContainsKey(pesel))
                {
                    ActorsQualif[pesel] = value;
                } 
                else
                {
                    throw new ArgumentException("Actor with that pesel already exists");
                }
            }
        }

        public Theater(string localiztion, string name)
        {
            (Localization, Name) = (localiztion, name);
            ActorsQualif = new Dictionary<string, Actor>();
        }
            
    }


    public class RealityShow
    {
        public string StationName { get; }
        public RealityShow(string stationName) => StationName = stationName;
    }
}
