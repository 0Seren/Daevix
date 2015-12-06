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

variable Type: name2
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
...
}
```
Methosds that don't return anything* should be declared as:
```
Name(param1, param2, ...) {
...
}
```
\*These actually return `Nil`

####Anonymous Functions
```
ReturnType: (params) -> {...}
```

####Parameters
Standard: `(Type: name, Type: name, ...)`
0 or More: `(Type*: name)`
1 or More: `(Type+: name)`
0 or 1: `(Type?: name)`
Default: `(Type: name = value)`

####Call
```
foo.baz(...).bar(...)

foo.baz(...)
   .bar(...)
```

##Classes and Objects
####Standard
```
class Name {
  ...
}
```
####Generics
```
class Name<T, ...> {

}
```
####Singleton
```
singleton Name {

}
```
####Object Data Members
Visible to the whole class.
```
class Name {
  Type: name = ...
  ...
}
```
####Constructors
Singleton constructors will be run when the program starts and cannot have parameters. All others will be run when declared. A create method with no parameters will be called when variables are not assigned immediately.
```
class Foo {
  create {
    ...
  }
  create(params) {
    ...
  }
}
```
####Destructors
Singleton destructors will be run when the program ends. All others will be run when out of scope or manually called. Destructors can have parameters, but one without will be the default one called.  
```
class Foo(params) {
  destroy {
    ...
  }
  destroy(params) {
    ...
  }
}
```
Destructors are optional and should only be used when you want to perform some special action at the end of an objects' life or when you want to manually control garbage collection. Creating an object with no destroy method is perfectly acceptable.
####Declarations
```
Type: name
Type: name = [params]
Type: name = Type(params)
Type: name = new Type(params)
```
####Destructions
```
{
  Type: name1
} #destroyed here

Type: name2
name2.destroy(params?)
```
