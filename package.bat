@if [%1]==[] @(
    @echo Specify source folder
    @exit )
@if [%2]==[] @(
    @echo Specify zip file
    @exit )
@set out=bin\Release\
@for /D %%s in (%1\*) do @(
    if exist %%s\%out% @(
        @echo adding %%s\%out% to %2
        @7z u %2 %%s\%out%* > 7z.log ))
