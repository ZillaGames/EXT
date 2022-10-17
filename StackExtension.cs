using System.Collections;
using System.Collections.Generic;
using System;

namespace StackExt
{
    public static class StackExtension
    {
        public static void PopAll<T>(this Stack<T> stack)
        {
            while (stack.Count > 0)
                stack.Pop();
        }

        public static void PopAll<T>(this Stack<T> stack, Action<T> action)
        {
            while (stack.Count > 0)
                action.Invoke(stack.Pop());
        }

        public static T SwitchTop<T>(this Stack<T> stack, T top)
        {
            var t = stack.Pop();
            stack.Push(top);
            return t;
        }
    }

}
