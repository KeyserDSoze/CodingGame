using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodinGame
{
    public class CodinGame
    {
        private IList<ICodinGame> Tests = new List<ICodinGame>();
        private string Namespace;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace">Namespace to remove to names of your ITest's implementation.</param>
        public CodinGame(string @namespace)
        {
            this.Namespace = @namespace;
            this.Tests = (Assembly.GetAssembly(typeof(ICodinGame)) ?? Assembly.GetAssembly(this.GetType())).GetTypes()
                .Where(x => typeof(ICodinGame).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .OrderBy(x => x.FullName)
                .Select(x => Activator.CreateInstance(x) as ICodinGame)
                .ToList();
        }
        private bool DoWork(int value)
        {
            if (value < 0)
                value = 0;
            if (value < this.Tests.Count)
            {
                this.Tests[value].Run();
                return true;
            }
            else
                throw new ArgumentException($"{nameof(value)} is greater than {nameof(this.Tests)}. {value} >= {this.Tests.Count}");
        }

        private string WhatDoYouWantToSeeInAction()
        {
            int value = 0;
            foreach (ICodinGame test in this.Tests)
                Console.WriteLine($"For {ToName(test)} use {value++}");
            Console.WriteLine("Write 'exit' if you want to close this app.");
            return Console.ReadLine();
        }
        private string ToName(ICodinGame test)
            => test.GetType().FullName.Replace(Namespace, "").Trim('.');
        private string Result;
        public void Start()
        {
            while ((Result = this.WhatDoYouWantToSeeInAction()) != "exit")
            {
                try
                {
                    Console.WriteLine("Insert your value");
                    Console.WriteLine($"Result: {this.DoWork(int.Parse(Result))}");
                    Console.WriteLine(string.Empty);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
            }
        }
    }
}
