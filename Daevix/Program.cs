using Daevix.CodeAnalysis;
using Daevix.CodeAnalysis.Binding;
using Daevix.CodeAnalysis.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Daevix
{
    internal static class Program
    {
        private static void Main()
        {
            var  showTree = false;

            while (true)
            {
                Console.Write(">");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                if ("#showTree".Equals(line, StringComparison.OrdinalIgnoreCase))
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees");
                    continue;
                }
                else if ("#cls".Equals(line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                var binder = new Binder();
                var boundExpression = binder.BindExpression(syntaxTree.Root);

                var diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics);

                if (showTree)
                {
                    PrintSyntaxTree(syntaxTree);
                }

                if (!diagnostics.Any())
                {
                    var e = new Evaluator(boundExpression);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    PrintDiagnostics(diagnostics);
                }
            }
        }

        private static void PrintSyntaxTree(SyntaxTree syntaxTree)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(syntaxTree);
            Console.ResetColor();
        }

        private static void PrintDiagnostics(IEnumerable<string> diagnostics)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var diagnostic in diagnostics)
            {
                Console.WriteLine(diagnostic);
            }
            Console.ResetColor();
        }
    }
}
