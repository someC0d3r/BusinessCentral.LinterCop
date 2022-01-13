using Microsoft.Dynamics.Nav.CodeAnalysis;
using Microsoft.Dynamics.Nav.CodeAnalysis.Diagnostics;
using Microsoft.Dynamics.Nav.CodeAnalysis.Syntax;
using System;
using System.Collections.Immutable;
using Microsoft.Dynamics.Nav.Analyzers.Common.AppSourceCopConfiguration;
using Microsoft.Dynamics.Nav.Analyzers.Common;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BusinessCentral.LinterCop.Design
{
    [DiagnosticAnalyzer]
    public class Rule0016PragmaWarningDisableMustBeExplainedByComment : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create<DiagnosticDescriptor>(DiagnosticDescriptors.Rule0016PragmaWarningDisableMustBeExplainedByComment);

        public override void Initialize(AnalysisContext context)
            => context.RegisterSyntaxNodeAction(new Action<SyntaxNodeAnalysisContext>(this.CheckPragmaComments), new SyntaxKind[]
                {
                    SyntaxKind.PragmaWarningDirectiveTrivia
                });

        private void CheckPragmaComments(SyntaxNodeAnalysisContext ctx)
        {
            if (ctx.ContainingSymbol.IsObsoletePending || ctx.ContainingSymbol.IsObsoleteRemoved) return;
            if (ctx.ContainingSymbol.GetContainingObjectTypeSymbol().IsObsoletePending || ctx.ContainingSymbol.GetContainingObjectTypeSymbol().IsObsoleteRemoved) return;
            if (((PragmaWarningDirectiveTriviaSyntax)ctx.Node).DisableOrRestoreKeyword.Value.ToString() != "disable") return;
            
            foreach (SyntaxTrivia syntaxTrivia in ctx.Node.GetLeadingTrivia())
            {
                if (syntaxTrivia.IsKind(SyntaxKind.LineCommentTrivia)) return;
            }

            foreach (SyntaxTrivia syntaxTrivia in ctx.Node.GetTrailingTrivia())
            {
                if (syntaxTrivia.IsKind(SyntaxKind.LineCommentTrivia)) return;
            }

            ctx.ReportDiagnostic(
                Diagnostic.Create(
                    DiagnosticDescriptors.Rule0016PragmaWarningDisableMustBeExplainedByComment,
                    ctx.Node.GetLocation()));
        }
    }
}
