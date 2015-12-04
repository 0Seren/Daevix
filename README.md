# Daevix:
A language or something

#Syntax/Design Docs(subject to change):
##Variables:
All variables in Daevix are, by default, `final`. Meaning you can only assign to a variable once unless declared otherwise. All variables are also defaultly set to `private[class]`
####Declaration:
```
Type: name
variable Type: name
```

####Assignment:
```
Type: name1 = value

Type: name2
name2 = value
```

####Scope:
Default set to `private[class]` (any objects of the same class can access).
Can explicitly declare types:
```
public Type: public_name
protected Type: protected_name
private[scope] Type: private_name

public variabe Type: name
```
Variables should delete themselves when they are no longer are in scope/have any valid references to them (aka garbage collection).

####Placeholder Character:
Akin to `_` in Scala `$` is the placeholder character in Daevix:
```
array.foreach(print($))
```

####Primitive Types:
The only primiive type in Daevix is `bit`

##Functions
All functions are, by default, public.
####Methods:
Methods that return a value should be declared as:
```
ReturnType: Name(param1, param2, ...) = {

}
```
Methosds that don't return anything* should be declared as:
```
Name(param1, param2, ...) {

}
```
\*These actually return `Nil`
