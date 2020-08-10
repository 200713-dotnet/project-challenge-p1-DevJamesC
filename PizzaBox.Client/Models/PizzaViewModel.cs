using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Models;

namespace PizzaBox.Client.Models
{
    public class PizzaViewModel
    {

        public PizzaViewModel()//this data should be rerieved from somewhere else (dynamically, rather than hardcoded here)
        {
            Crusts= new List<CrustModel>(){new CrustModel{Name="Plane",Price=0},new CrustModel{Name="Garlic",Price=.5m},new CrustModel{Name="Stuffed",Price=2}};
            Sizes = new List<SizeModel>(){new SizeModel{Name="Small",Price=0},new SizeModel{Name="Medium",Price=2},new SizeModel{Name="Large",Price=3}};
            Toppings = new List<ToppingModel>(){new ToppingModel{Name="Top1",Price=.25m},new ToppingModel{Name="Top2",Price=.5m},new ToppingModel{Name="Top3",Price=.75m}};
            SelectedToppings= new List<string>();

            // for (int i = 0; i < Toppings.Count; i++)
            // {
            //     var newCheckTop= new CheckModel(){Id=i,Name=Toppings[i].Name, Checked=false};

            //     SelectedToppings.Add(newCheckTop);
            // }
            
        }
        public List<CrustModel> Crusts { get; set; }
        public List<SizeModel> Sizes { get; set; }
        public List<ToppingModel> Toppings { get; set; }

        public UserViewModel UserVM { get; set; }

//user inputs
        [Required]
        public string Crust { get; set; }
        [Required]
        public string Size { get; set; }
        [Range(1, 5)]
        public List<string> SelectedToppings { get; set; }

        public bool Selected { get; set; }

        public PizzaModel AssemblePizza()
        {
                PizzaModel p = new PizzaFactory().Create();
                p.Price=6;
                    foreach (var c in Crusts)
                    {
                        if(c.Name==Crust)
                        {
                            p.Crust=c;
                        }
                    }

                    foreach (var s in Sizes)
                    {
                        if(s.Name==Size)
                        {
                            p.Size=s;
                        }
                    }

                    foreach (var t in Toppings)
                    {
                        foreach (var st in SelectedToppings)
                        {
                             if(t.Name==st)
                        {
                            p.Toppings.Add(t);
                        }
                        }
                       
                    }


                return p;
        }
       // public bool SelectedTopping { get; set; }
        //create a new model CheckBoxTopping. has prop bool IsSelected. Then change selectedTopping from a bool to a list of CheckBoxTopping... if we want to use the htmlhelper or razer.
    }
}
