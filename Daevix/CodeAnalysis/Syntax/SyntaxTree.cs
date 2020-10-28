using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daevix.CodeAnalysis.Syntax
{
    public sealed class SyntaxTree
    {
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken endOfFileToken)
        {
            Diagnostics = diagnostics.ToArray();
            Root = root;
            EndOfFileToken = endOfFileToken;
        }

        public IReadOnlyList<string> Diagnostics { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndOfFileToken { get; }

        public static SyntaxTree Parse(string text)
        {
            var parser = new Parser(text);
            return parser.Parse();
        }

        public override string ToString()
        {
            var sb = ToStringHelper(Root);
            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        private StringBuilder ToStringHelper(SyntaxNode node, string indent = "", bool isLast = true)
        {
            StringBuilder sb = new StringBuilder();

            var marker = isLast ? "└──" : "├──";

            sb.Append(indent);
            sb.Append(marker);
            sb.Append(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                sb.Append(" ");
                sb.Append(t.Value);
            }

            sb.AppendLine();
            indent += isLast ? "   " : "│  ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
            {
                sb.Append(ToStringHelper(child, indent, child == lastChild));
            }

            return sb;
        }
    }
}
