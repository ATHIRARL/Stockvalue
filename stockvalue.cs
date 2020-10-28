using System;
using System.Linq;
using System.Collections.Generic;

					
public class Program
{
	public static void Main()
	{
		
             
		
 	Console.WriteLine("Enter number of Periods");
		   var n = long.Parse( Console.ReadLine());
	
	  var s = new Stock[n];
	       
		IDictionary<int,  Stock> sto = new Dictionary<int,Stock>();
		for (int i = 0; i < n; i++) 
		{
			 Console.WriteLine("Enter time");
			
			s[i]=new Stock();
			s[i].stocktime = DateTime.Parse(string.Format("{0:HH:mm:ss tt }",  Console.ReadLine()));
			
			  Console.WriteLine("Enter stock price");
               s[i].price = double.Parse(Console.ReadLine());
			sto.Add(i,s[i]);
			
			
	
		
		
		}
	
		 Console.WriteLine("Data Given");
		foreach (var kvp in sto)
            {
              Console.WriteLine(kvp.Key+ " " + kvp.Value.price+" "+kvp.Value.stocktime);
            }

double maxProfit = 0;
      double currentBuy = sto.Where(x => x.Key == 0).FirstOrDefault().Value.price;
		 
      double currentSell = sto.Where(x => x.Key == 0).FirstOrDefault().Value.price;
		 var curbt =sto.Where(x => x.Key == 0).FirstOrDefault().Value.stocktime; 
			 var curst=sto.Where(x => x.Key == 0).FirstOrDefault().Value.stocktime;
      for(int i = 0; i <sto.Count() ; i++){
          if((sto.Where(x => x.Key == i).FirstOrDefault().Value.price) < currentBuy){
              currentBuy =sto.Where(x => x.Key == i).FirstOrDefault().Value.price; 
              currentSell = sto.Where(x => x.Key == i+1).FirstOrDefault().Value.price;
			  
              if(currentSell - currentBuy > maxProfit){
                    maxProfit = currentSell - currentBuy;
              }
          } else if((sto.Where(x => x.Key == i).FirstOrDefault().Value.price) > currentSell){
              currentSell = sto.Where(x => x.Key == i).FirstOrDefault().Value.price;
              if(currentSell - currentBuy > maxProfit){
                   maxProfit = currentSell - currentBuy;
               }
			 
           }
		    curbt =sto.Where(x =>x.Value.price==currentBuy ).FirstOrDefault().Value.stocktime; 
			  curst=sto.Where(x => x.Value.price==currentSell).FirstOrDefault().Value.stocktime;
         }
		 
		Console.WriteLine("Maxium Profit "+(maxProfit));
		Console.WriteLine("Buying Time "+(curbt.ToLongTimeString()));
			Console.WriteLine("Buying Price "+(currentBuy ));
		Console.WriteLine("Selling Price "+(currentSell ));
		Console.WriteLine("Selling Time "+(curst.ToLongTimeString() ));
		

	 
	
	
	}


	
}

public class Stock
{
    public DateTime stocktime { get; set; }
    public double price { get; set; }


}