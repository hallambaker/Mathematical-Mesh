~~~~
URI           = "UDF:" udf [ "?" query ] [ "" fragment ]

udf           = name-form / locator-form

name-form     = udf-value
locator-form  = "//" authority "/" udf-value

authority     = host 
host          = reg-name
~~~~
