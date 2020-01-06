using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Dynamic_sorting
{
    internal class Solution : ICodinGame
    {
        private static string Expression = "-age+name+sex+surname";
        private static string Ordered = "int,string,string,string";
        private static List<string> Inputs = new List<string>()
        {
            "id:1,name:maria,surname:aa,age:1,sex:male",
            "id:2,name:jason,surname:tt,age:12,sex:male",
            "id:3,name:jason,surname:pp,age:14,sex:male",
            "id:4,name:hugo,surname:dd,age:9,sex:female",
            "id:5,name:amit,surname:rr,age:2,sex:female",
            "id:6,name:maria,surname:tt,age:21,sex:male",
            "id:7,name:maria,surname:zz,age:21,sex:female",
        };
        public void Run()
        {
            int N = Inputs.Count;
            LogicObject logicObject = new LogicObject(Ordered, Expression);
            List<DynamicObject> values = new List<DynamicObject>();
            for (int i = 0; i < N; i++)
            {
                string ROW = Inputs[i];
                values.Add(new DynamicObject(ROW, logicObject));
            }
            IOrderedEnumerable<DynamicObject> result = GetOrders(values, logicObject.Instance.Dequeue());
            while (logicObject.Instance.Count > 0)
                result = ThenOrders(result, logicObject.Instance.Dequeue());
            foreach (DynamicObject dynamicObject in result)
                Console.WriteLine(dynamicObject.Id);
        }
        public static IOrderedEnumerable<DynamicObject> GetOrders(IEnumerable<DynamicObject> values, Logic logic)
        {
            if (logic.IsInteger)
                return logic.Ascending ? values.OrderBy(x => x.IntValues[logic.Name]) : values.OrderByDescending(x => x.IntValues[logic.Name]);
            else
                return logic.Ascending ? values.OrderBy(x => x.StringValues[logic.Name]) : values.OrderByDescending(x => x.StringValues[logic.Name]);
        }
        public static IOrderedEnumerable<DynamicObject> ThenOrders(IOrderedEnumerable<DynamicObject> values, Logic logic)
        {
            if (logic.IsInteger)
                return logic.Ascending ? values.ThenBy(x => x.IntValues[logic.Name]) : values.ThenByDescending(x => x.IntValues[logic.Name]);
            else
                return logic.Ascending ? values.ThenBy(x => x.StringValues[logic.Name]) : values.ThenByDescending(x => x.StringValues[logic.Name]);
        }
    }
}
