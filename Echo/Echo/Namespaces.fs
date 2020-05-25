namespace A

type Person = {name:string}
type Thing = {a:int}

namespace B
type Person = {age:int; otherPerson: A.Person;}

open A

type ThingWrapper = {t:Thing}

//let square x = x * x 
