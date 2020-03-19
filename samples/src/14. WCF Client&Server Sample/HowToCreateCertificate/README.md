1) Download openssl: http://gnuwin32.sourceforge.net/packages/openssl.htm
Or use exe provided in this folder.

2) open command line in directory with openssl.exe and execute command:
set RANDFILE=.rnd

3) Creating private-public pair and fill certificate information. Provide meaningful information for each property. In the command line: 
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout private.pem -out public.pem -config "openssl.cnf"  

4) Exporting certificate as p12. Provide reasonable password and remember it. In command line:
openssl pkcs12 -export -out certificate.p12 -inkey private.pem -in public.pem

5) Install p12. Double click, type password from step 4) import it into following stores 
-   LocalMachine -> My 
-   LocalMachine -> Trusted Root Certificate Authority
