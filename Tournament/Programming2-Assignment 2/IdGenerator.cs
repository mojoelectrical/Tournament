using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    static class IdGenerator
    {
        private static uint nextId = 100;


        public static uint GetId() {
            nextId++;
            return nextId;
        }

    }
}