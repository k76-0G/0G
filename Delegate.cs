using Act = System.Action;

namespace _0G
{
    public static class Delegate
    {
        public static void Launch(ref Act action)
        {
            Act a = action;
            action = null;
            a?.Invoke();
        }
    }
}