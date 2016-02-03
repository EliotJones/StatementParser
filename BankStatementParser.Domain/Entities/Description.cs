namespace BankStatementParser.Domain.Entities
{
    using System;

    public struct Description
    {
        public string Text { get; private set; }

        public Description(string description)
        {
            if (description == null)
            {
                throw new NullReferenceException();
            }

            Text = description;
        }

        public bool ContainsFragment(string fragment)
        {
            return Text.IndexOf(fragment, 0, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        public bool StartsWithFragment(string fragment)
        {
            return Text.StartsWith(fragment, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool EndWithFragment(string fragment)
        {
            return Text.EndsWith(fragment, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsFragment(string fragment)
        {
            if (fragment == null)
            {
                return false;
            }

            return Text.Equals(fragment, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool ContainsFragmentAsWord(string fragment)
        {
            var index = Text.IndexOf(fragment, 0, StringComparison.InvariantCultureIgnoreCase);
            if (index < 0)
            {
                return false;
            }

            if (index > 0 && !char.IsWhiteSpace(Text[index - 1]))
            {
                return false;
            }

            if (index < Text.Length - 1 && !char.IsWhiteSpace(Text[index + 1]))
            {
                return false;
            }

            return true;
        }
    }
}
