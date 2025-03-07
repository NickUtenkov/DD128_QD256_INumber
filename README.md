# DD128_QD256_INumber

.NET double-double(104-bit) and quad-double(209-bit) library implementing C# INumber interface.

Based on NetQD(https://github.com/rzikm/NetQD), which is based on QD library(https://github.com/aoki-t/QD).

Suported interfaces :\
INumber,\
ILogarithmicFunctions,\
IPowerFunctions,\
IExponentialFunctions,\
IMinMaxValue,\
IRootFunctions,\
ITrigonometricFunctions,\
IHyperbolicFunctions,\
IFloatingPointConstants,\
IConvertible

When printing, if you do not use a format, the following will be printed:\
for DD128 32 decimal digits.\
for QD256 63 decimal digits.

If any format is used, only the first component of the number will be printed.
