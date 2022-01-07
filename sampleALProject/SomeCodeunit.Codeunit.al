codeunit 50100 "Some Codeunit"
{
    local procedure SomeFancyMethod()
    var
        SalesLine: Record "Sales Line";
        ItemLedgerEntry: Record "Item Ledger Entry";
        SomeTable: Record "Some Table";
        purchaseLine: Record "Purchase Line";
        SomeText: Text[10];
    begin
        SalesLine.Reset();
        SalesLine.SetRange(Description, '<>0');
        purchaseLine.Reset();


        someText := '1234567890';

        ItemLedgerEntry.Reset();
        SomeFancyMethod();

        SomeTable.Reset();
        SomeTable.FindFirst();
        SalesLine.SetRange(Description, SomeTable."Abc < Def");
        SalesLine.SetRange(Description, SomeTable."Abc < Def", '0');
    end;
}