using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Check("null, null", Comparer.Compare(null, null), true);
                Check("null, 1", Comparer.Compare(null, 1), false);
                Check("'', null", Comparer.Compare("", null), false);
                Check("1, 1", Comparer.Compare(1, 1), true);
                Check("1, '1'", Comparer.Compare(1, "1"), false);
                Check("1, 2", Comparer.Compare(1, 2), false);
                Check("'aaa', 'aaa'", Comparer.Compare("aaa", "aaa"), true);
                Check("dict", Comparer.Compare(
                    new Dictionary<string, string> { { "Id", "1" }, { "Title", "My title" } },
                    new Dictionary<string, string> { { "Id", "1" }, { "Title", "My title2" } }), false);
                Check("list", Comparer.Compare(
                    new List<string> { "Id", "1", "Title", "My title" },
                    new List<string> { "Id", "1", "Title" }), false);
                Check("list2", Comparer.Compare(
                    new List<string> { "Id", "1", "Title", "My title" },
                    new List<string> { "Id", "1", "Title", "My title2" }), false);
                Check("array", Comparer.Compare(new int[10], new int[12]), false);
                A[] a1 = new A[2]; a1[1] = new A() { ClassData = new C() };
                A[] a2 = new A[2]; a2[1] = new A() { ClassData = new C() { AListData = new List<A>() } };
                Check("array2", Comparer.Compare(a1, a2), false);
                Check("anonym", Comparer.Compare(new { Amount = 108, Message = "Hello" }, new { Amount = 108, Message = "Hello" }), true);
                Check("anonym2", Comparer.Compare(new { Amount = 108, Message = "Hello" }, new { Amount = 108, Message = "Hello2" }), false);

                A aa1 = new A() { IntProp = 1, StringProp = "111", StructProp = new S(), ClassProp = new C(),
                    ListIntProp = new List<int>() { 1, 2 }, ListStringProp = new List<string> { "111", "222" }, ListStructProp = new List<S>(), ListClassProp = new List<C>(),
                    IntData = 1, StringData = "111", StructData = new S(), ClassData = new C(),
                    ListIntData = new List<int>() { 1, 2 }, ListStringData = new List<string> { "111", "222" }, ListStructData = new List<S>(), ListClassData = new List<C>(),
                    DictProp = new Dictionary<string, C>(), DictData = new Dictionary<string, C>()
                };
                A aa2 = new A() { IntProp = 1, StringProp = "111", StructProp = new S(), ClassProp = new C(),
                    ListIntProp = new List<int>() { 1, 2 }, ListStringProp = new List<string> { "111", "222" }, ListStructProp = new List<S>(), ListClassProp = new List<C>(),
                    IntData = 1, StringData = "111", StructData = new S(), ClassData = new C(),
                    ListIntData = new List<int>() { 1, 2 }, ListStringData = new List<string> { "111", "222" }, ListStructData = new List<S>(), ListClassData = new List<C>(),
                    DictProp = new Dictionary<string, C>(), DictData = new Dictionary<string, C>()
                };
                Check("complex equal", Comparer.Compare(aa1, aa2), true);

                S s1 = new S() { AData = aa1, AListData = new List<A> { aa1, aa2 }, ADictData = new Dictionary<int, A> { { 1, aa1 } },
                    AProp = aa1, AListProp = new List<A> { aa1, aa2 }, ADictProp = new Dictionary<int, A> { { 1, aa1 } } };
                S s2 = new S() { AData = aa1, AListData = new List<A> { aa1, aa2 }, ADictData = new Dictionary<int, A> { { 1, aa1 } },
                    AProp = aa1, AListProp = new List<A> { aa1, aa2 }, ADictProp = new Dictionary<int, A> { { 1, aa1 } } };

                //do any changes
                aa2.ListIntData[0] = 3;
                Check("complex not equal", Comparer.Compare(aa1, aa2), false);

                Check("struct", Comparer.Compare(s1, s2), true);
                s2.AData = aa2;
                Check("struct not equal", Comparer.Compare(s1, s2), false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Check(string info, string comp, bool fine)
        {
            string res = "Fail";
            if (comp != null && !fine)
                res = "Ok";
            if (comp == null && fine)
                res = "Ok";

            if (comp == null)
                comp = "equal";

            Console.WriteLine(info + ": " + comp + " - " + res);
        }

        class A
        {
            //properties
            public int IntProp { get; set; }
            public string StringProp { get; set; }
            public S StructProp { get; set; }
            public C ClassProp { get; set; }

            public List<int> ListIntProp { get; set; }
            public List<string> ListStringProp { get; set; }
            public List<S> ListStructProp { get; set; }
            public List<C> ListClassProp { get; set; }

            public Dictionary<string, C> DictProp { get; set; }

            //data
            public int IntData;
            public string StringData;
            public S StructData;
            public C ClassData;

            public List<int> ListIntData;
            public List<string> ListStringData;
            public List<S> ListStructData;
            public List<C> ListClassData;

            public Dictionary<string, C> DictData;
        }

        struct S
        {
            public A AProp { get; set; }
            public List<A> AListProp { get; set; }
            public Dictionary<int, A> ADictProp { get; set; }

            public A AData;
            public List<A> AListData;
            public Dictionary<int, A> ADictData;
        }

        class C
        {
            public A AProp { get; set; }
            public List<A> AListProp { get; set; }
            public Dictionary<int, A> ADictProp { get; set; }

            public A AData;
            public List<A> AListData;
            public Dictionary<int, A> ADictData;
        }
    }
}
