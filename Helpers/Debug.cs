using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Dynamics.Nav.CodeAnalysis.Diagnostics;

namespace BusinessCentral.LinterCop.Helpers {
    public class Debug {

        public static void ThrowDebugDiagnostic(ref SymbolAnalysisContext context, string id, string message) {
            DiagnosticDescriptor DebugDescriptor =
                new DiagnosticDescriptor(
                    id,
                    message,
                    message,
                    "Design",
                    DiagnosticSeverity.Info,
                    true,
                    message);

            context.ReportDiagnostic(Diagnostic.Create(DebugDescriptor,context.Symbol.Location,new object[] { }));
        }

        public static void ThrowDebugDiagnostic(ref SymbolAnalysisContext context, string id, string message, Microsoft.Dynamics.Nav.CodeAnalysis.Text.Location location) {
            DiagnosticDescriptor DebugDescriptor =
                new DiagnosticDescriptor(
                    id,
                    message,
                    message,
                    "Design",
                    DiagnosticSeverity.Info,
                    true,
                    message);

            context.ReportDiagnostic(Diagnostic.Create(DebugDescriptor, location, new object[] { }));
        }
    }
}
