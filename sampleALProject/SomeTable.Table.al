table 50100 "Some Table"
{
    Caption = 'Some Table';
    DataClassification = ToBeClassified;
    LookupPageId = "Some Table List";

    fields
    {
        field(10; "Entry No."; Integer)
        {
            Caption = 'Entry No.';
            DataClassification = ToBeClassified;
        }
        field(20; "Some Text"; Text[100])
        {
            Caption = 'Some Text';
            DataClassification = ToBeClassified;
        }
        field(30; "Some FlowField"; Integer)
        {
            Caption = 'Some FlowField';
            FieldClass = FlowField;
            CalcFormula = Count("Some Table" where("Entry No." = const(1)));
        }
        field(40; "Abc < Def"; Text[100])
        {
            Caption = 'Abc < Def';
            DataClassification = ToBeClassified;
        }
    }
    keys
    {
        key(PK; "Entry No.")
        {
            Clustered = true;
        }
    }

    trigger OnInsert()
    begin
        SetRange("Some Text", '0');
    end;
}