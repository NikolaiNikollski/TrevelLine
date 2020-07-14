PROGRAM TextToCodeConverter(INPUT, OUTPUT); {CP866}
VAR
  Ch: CHAR;
  DecInt: INTEGER;
  Dec, Hex, Bin: STRING;

FUNCTION DecIntToStr(Num: INTEGER): STRING;
VAR
  NumStr: STRING;
BEGIN
  Str(Num, NumStr);
  IF Num < 100 //Двузначное
  THEN
    DecIntToStr := '0' + NumStr
  ELSE
    DecIntToStr := NumStr
END;

FUNCTION DecToBin(Num: INTEGER): STRING;
VAR
  I: INTEGER;
BEGIN {DecToBinStr}
  DecToBin := '';
  I :=  128;
  WHILE I <> 0
  DO
    BEGIN
      IF Num >= I
      THEN
        BEGIN
          Num := Num - I;
          DecToBin := DecToBin + '1';
        END
      ELSE
        DecToBin := DecToBin + '0';
      I := I DIV 2
    END
END; {DecToBinStr}

FUNCTION HexDigitToChar(Digit: INTEGER): STRING;
BEGIN
  HexDigitToChar := '';
  CASE Digit OF
  10: HexDigitToChar := 'A';
  11: HexDigitToChar := 'B';
  12: HexDigitToChar := 'C';
  13: HexDigitToChar := 'D';
  14: HexDigitToChar := 'E';
  15: HexDigitToChar := 'F'
  ELSE
    STR(Digit, HexDigitToChar)
  END
END;

FUNCTION DecToHex(Num: INTEGER): STRING;
VAR
  FirstRank, SecondRank: INTEGER;
BEGIN {DecToBinStr}
  DecToHex := '';
  FirstRank := Num DIV 16;
  SecondRank := Num MOD 16;
  DecToHEx := HexDigitToChar(FirstRank) + HexDigitToChar(SecondRank)

END; {DecToBinStr}


BEGIN {TextToCodeConverter}
  ASSIGN(OUTPUT, 'output.txt');
  REWRITE(OUTPUT);
  IF NOT EOLN THEN WRITELN('Char ', 'Dec ', 'Hex ', 'Bin ');
  WHILE NOT EOLN
  DO
    BEGIN
      READ(Ch);
      DecInt := ORD(Ch);
      Dec := DecIntToStr(DecInt);
      Bin := DecToBin(DecInt);
      Hex := DecToHex(DecInt);
      WRITELN(Ch, '    ', Dec, ' ', Hex, '  ', Bin);
    END;
END. {TextToCodeConverter}
