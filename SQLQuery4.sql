CREATE Or ALTER FUNCTION GetPersonenDetails(@Id INT) 
Returns
@Ergebnis Table 

(

        Id Int,
        [Name] NVARCHAR(MAx),
        AktivStr VARCHAR(15),
        PersonenTyp NVARCHAR(MAx)
)
As
Begin
    Insert @Ergebnis
    Select
        p.Id,
        p.Vorname + ' ' + p.Nachname,
        CASE WHEN p.IstAktiv = 1 THEN 'Aktiv' ELSE 'Inaktiv' END,
        pt.Beschreibung
    From 
        Person p Inner join PersonenTyp pt on p.PersonenTypId =pt.Id
    Where
    p.Id = @Id

Return
End

go