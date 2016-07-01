SELECT SUBSTRING(Buurtcode, 9, 10) AS Buurtcodes_Wijken
FROM Wijken
ORDER BY SUBSTRING(Buurtcode, 9, 10) ASC;

SELECT DISTINCT SUBSTRING(Buurtcode, 3, 6) AS Buurtcodes_Deelgemeentes
FROM Wijken
ORDER BY SUBSTRING(Buurtcode, 3, 6)

SELECT DISTINCT SUBSTRING(Buurt, 1, 2) AS Buurten_Fietsdiefstal
FROM Fietsdiefstal
ORDER BY SUBSTRING(Buurt, 1, 2);

