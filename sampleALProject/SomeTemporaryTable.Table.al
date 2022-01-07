table 50101 "Some Temporary Table"
{
    Caption = 'Some Table';
    DataClassification = ToBeClassified;
    TableType = Temporary;

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
    }
    keys
    {
        key(PK; "Entry No.")
        {
            Clustered = true;
        }
    }
}