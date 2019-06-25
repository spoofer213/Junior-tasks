using System;
using System.Collections.Generic;

namespace TaskThree
{

    /// Задача - перепишите данный код так, чтобы он работал через коллекции C#, вместо конструкции switch


    public enum ActionType
    {
        Create,

        Read,

        Update,

        Delete
        
    }
    

    class Program
    {
        public static Dictionary<ActionType, Action<ActionType>> typesWithActions = new Dictionary<ActionType, Action<ActionType>>()
            {
                {ActionType.Create, CreateMethod},
                {ActionType.Read, ReadMethod},
                {ActionType.Update, UpdateMethod},
                {ActionType.Delete, DeleteMethod},
            };
        static void Main(string[] args)
        {
            var type = ActionType.Read;

            if (typesWithActions.ContainsKey(type)){
                typesWithActions[type](type);                
            }
            
            Console.ReadKey();
        }

        private static void CreateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void ReadMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void UpdateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void DeleteMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
}
