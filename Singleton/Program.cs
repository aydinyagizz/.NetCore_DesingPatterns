using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;


        //bir nesneyi aynı anda iki kullanıcı isterse ve o nesne henüz üretilmemişse 2 tane üretmesin diye yaptığımız işlem
        static object _lockObject = new object();

        // dış erişime engellemek için private CustomerManager() oluşturuyoruz.
        private CustomerManager()
        {

        }


        //Singleton örneği. 
        public static CustomerManager CreateAsSingleton()
        {
            //bir nesneyi aynı anda iki kullanıcı isterse ve o nesne henüz üretilmemişse 2 tane üretmesin diye yaptığımız işlem
            lock (_lockObject)
            {
                // eğer CustomerManager nesnesinden daha önce oluşturulmuş varsa oluşmuş nesneyi verecez. yoksa yeni bir tane oluşturacağız

                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
           
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }

    }
}
