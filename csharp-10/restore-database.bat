RESTORE FILELISTONLY
FROM DISK = 'C:\Users\Carla\codenation\csharp-10\Codenation.bak'

RESTORE DATABASE Codenation
FROM DISK = 'C:\Users\Carla\codenation\csharp-10\Codenation.bak'

WITH MOVE 'Codenation' TO 'C:\Users\Carla\codenation\csharp-10\Codenation.mdf',
MOVE 'Codenation_log' TO 'C:\Users\Carla\codenation\csharp-10\Codenation.ldf',
REPLACE;