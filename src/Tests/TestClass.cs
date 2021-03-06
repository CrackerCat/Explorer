﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

namespace Explorer.Tests
{
    public static class StaticTestClass
    {
        public static int StaticProperty => 5;

        public static int StaticField = 69;

        public static List<string> StaticList = new List<string>
        {
            "one",
            "two",
            "three",
        };

        public static void StaticMethod() { }

    }

    public class TestClass
    {
        public static TestClass Instance => m_instance ?? (m_instance = new TestClass());
        private static TestClass m_instance;

        public static int StaticProperty => 5;
        public static int StaticField = 5;
        public int NonStaticField;

#if CPP
        public static Il2CppSystem.Collections.Generic.HashSet<string> ILHashSetTest;
#endif

        public TestClass()
        {
#if CPP
            ILHashSetTest = new Il2CppSystem.Collections.Generic.HashSet<string>();
            ILHashSetTest.Add("1");
            ILHashSetTest.Add("2");
            ILHashSetTest.Add("3");
#endif
        }

        public static string TestRefInOutGeneric<T>(ref string arg0, in int arg1, out string arg2)
        {
            arg2 = "this is arg2";

            return $"T: '{typeof(T).FullName}', ref arg0: '{arg0}', in arg1: '{arg1}', out arg2: '{arg2}'";
        }

        // test a non-generic dictionary

        public Hashtable TestNonGenericDict()
        {
            return new Hashtable
            {
                { "One",   1 },
                { "Two",   2 },
                { "Three", 3 },
            };
        }

        // test HashSets

        public static HashSet<string> HashSetTest = new HashSet<string>
        {
            "One",
            "Two",
            "Three"
        };


        // Test indexed parameter

        public string this[int arg0, string arg1]
        {
            get
            {
                return $"arg0: {arg0}, arg1: {arg1}";
            }
        }

        // Test basic list

        public static List<string> TestList = new List<string>
        {
            "1",
            "2",
            "3",
            "etc..."
        };

        // Test a nested dictionary

        public static Dictionary<int, Dictionary<string, int>> NestedDictionary = new Dictionary<int, Dictionary<string, int>>
        {
            {
                1,
                new  Dictionary<string, int>
                {
                    {
                        "Sub 1", 123
                    },
                    {
                        "Sub 2", 456
                    },
                }
            },
            {
                2,
                new  Dictionary<string, int>
                {
                    {
                        "Sub 3", 789
                    },
                    {
                        "Sub 4", 000
                    },
                }
            },
        };

        // Test a basic method

        public static Color TestMethod(float r, float g, float b, float a)
        {
            return new Color(r, g, b, a);
        }

        // A method with default arguments

        public static Vector3 TestDefaultArgs(float arg0, float arg1, float arg2 = 5.0f)
        {
            return new Vector3(arg0, arg1, arg2);
        }
    }
}
