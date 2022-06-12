namespace TwentyOne.Extensions
{
    public static class StackExtension
    {
        public static Stack<T> Shuffle<T>(this Stack<T> stack)
        {
            List<T> list = stack.ToList();
            list.Shuffle();
            return list.ToStack();
        }

        public static void Shuffle<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int num = Random.Shared.Next(list.Count);
                T temp = list[i];
                list[i] = list[num];
                list[num] = temp;
            }
        }

        public static Stack<T> ToStack<T>(this List<T> list)
        {
            Stack<T> stack = new Stack<T>();
            foreach (T t in list) stack.Push(t);
            return stack;
        }
    }
}
