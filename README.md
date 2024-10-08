# FP1
## Лабораторная работа №1 

## Язык - F#

### Задачи
 1. **Задача 11** найти максимальное произведение 4х чисел, стоящих подряд в одном направлении в массиве
 2. **Задача 20** найти сумму цифр факториала

 ### Решение задачи 11
 #### 1. Решение через рекурсию

 Рекурсивно обходим массив и ищем максимум
 Тут есть pattern matching

 ```f#
 let task11Rec grid =
    let getHorizontalProd (grid: int list list) (i: int) (j: int) =
        grid[i][j] * grid[i][j + 1] * grid[i][j + 2] * grid[i][j + 3]

    let getVerticalProd (grid: int list list) (i: int) (j: int) =
        grid[i][j] * grid[i + 1][j] * grid[i + 2][j] * grid[i + 3][j]

    let getDiagonalPositiveProd (grid: int list list) (i: int) (j: int) =
        grid[i][j] * grid[i + 1][j + 1] * grid[i + 2][j + 2] * grid[i + 3][j + 3]

    let getDiagonalNegativeProd (grid: int list list) (i: int) (j: int) =
        grid[i][j] * grid[i + 1][j - 1] * grid[i + 2][j - 2] * grid[i + 3][j - 3]

    let maxProductRecurcive (grid: int list list) =
        let rec loop (grid: int list list) i j =
            match (i, j) with
            | _, j when j > (List.length (List.head grid) - 4) -> loop grid (i + 1) 0
            | i, _ when i > (List.length grid - 4) -> 0
            | _ ->
                max
                    (max
                        (getHorizontalProd grid i j)
                        (max
                            (getVerticalProd grid i j)
                            (max
                                (getDiagonalPositiveProd grid i j)
                                (if j > 3 then getDiagonalNegativeProd grid i j else 0))))
                    (loop grid i (j + 1))

        loop grid 0 0

    maxProductRecurcive grid
 ```

#### 2. Решение через спец синтаксис для циклов/sequence 

более красивое решение с fold map 

```f#

let task11Loop grid =
    let getElement grid x y =
        if x >= 0 && x < List.length grid && y >= 0 && y < List.length (List.head grid) then
            Some(List.item y (List.item x grid))
        else
            None


    let getProduct (grid: int list list) (coordinates: (int * int) list) =
        coordinates
        |> List.choose (fun (x, y) -> getElement grid x y)
        |> List.fold (*) 1


    let directions =
        [
          // Вправо
          [ (0, 0); (0, 1); (0, 2); (0, 3) ]
          // Вниз
          [ (0, 0); (1, 0); (2, 0); (3, 0) ]
          // Диагональ вправо вниз
          [ (0, 0); (1, 1); (2, 2); (3, 3) ]
          // Диагональ влево вниз
          [ (0, 0); (-1, 1); (-2, 2); (-3, 3) ] ]

    // что то похожее на модульную реализацию
    let getMaxProduct (grid: int list list) =
        [ for x in 0 .. List.length grid - 1 do
              for y in 0 .. List.length (List.head grid) - 1 do
                  for direction in directions do
                      yield List.map (fun (dx, dy) -> (x + dx, y + dy)) direction ]
        |> List.map (getProduct grid)
        |> List.max

    getMaxProduct grid

```

#### решение на Python

```python

def prod(arr):
    production = 1
    for e in arr: production *= e
    return production

res = 0

for i in range (len(lst) - 3):
    for j in range(len(lst[0]) - 3):
        prod1 = prod(lst[i][j+x]  for x in range(4))
        prod2 = prod(lst[i+x][j]  for x in range(4))
        prod3 = prod(lst[i+x][j+x] for x in range(4))
        if j >= 3: prod3 = max(prod3, prod(lst[i+x][j-x] for x in range(4)))
        res = max(res, prod1, prod2, prod3)

print(res)
```


### Решение задачи 20

#### 1. Решение через рекурсию (хвостовая + обычная)

```f#
let task20RecursionSolution n =
    let rec factorial n =
        let rec loop acc i =
            if i = 0 then acc else loop (acc * bigint i) (i - 1)

        loop 1I n

    let rec sumOfDigits (n: bigint) : int =
        if n < 10I then
            int n
        else
            int (n % 10I) + sumOfDigits (n / bigint 10)

    factorial n |> sumOfDigits
```

#### 2. Модульное решение
для разнообразия присутствует преобразование в строку для подсчета суммы цифр
```f#
let task20ModuleSolution n =
    let factorial (n: int) =
        let bigN = bigint n
        [ 1I .. bigN ] |> List.fold (*) 1I

    let sumOfDigits n =
        n.ToString() |> Seq.map (fun c -> int (string c)) |> Seq.sum

    factorial n |> sumOfDigits
```


#### 3. Решение через ленивые вычисления

```f#
let task20SequenceSolution n =
    let factorial (n: int) =
        let bigN = bigint n
        seq { 1I .. bigN } |> Seq.scan (*) 1I |> Seq.last

    let rec sumOfDigits (n: bigint) : int =
        match n with
        | n when n < 10I -> int n
        | _ -> int (n % 10I) + sumOfDigits (n / bigint 10)

    factorial n |> sumOfDigits
```

#### Решение на Python
```python
fac = 1
n = 100

for i in range(2, n+1):
    fac *= i

fac = str(fac)
res = 0
for s in fac:
    res+= int(s)

print(res)
```


### Вывод

Эта лабораторная работа позволила мне познакомиться с базовыми концепциями и инструментами языка F#, теперь я готов к решению более сложных и комплексных задач. 

Неприятной особенностью языка оказалась автоматическое приведение типов. В компилируемом языке от этого не сильно много смысла и чаще удобнее прописать тип, чем после ловить ругательные сообщения от компилятора.

Код на питоне выглядит приятнее и компактнее, возможно от того что я с ним знаком дольше чем с F#, но это не точно)



### Правки

#### Более красивое решение задачи 11

Учитываются только 2 направления - горизонталь и вертикаль

```f#
let task11BeautifullSolution (grid: int list list) =
    let n = List.length grid

    let getElement (grid: int list list) x y =
        if x >= 0 && x < List.length grid && y >= 0 && y < List.length (List.head grid) then
            List.item y (List.item x grid)
        else
            0

    [ for a in 0 .. (n - 5) do
          for b in 0 .. (n - 1) do
              yield (a, b) ]
    |> List.map (fun (x, y) ->
        [ for i in 0..3 do
              yield getElement grid y (x + i), getElement grid (y + i) (x) ])
    |> List.map (fun (x) ->
        x
        |> List.fold (fun (acc1: int, acc2: int) (x: int, y: int) -> (acc1 * x, acc2 * y)) (1, 1))
    |> List.map (fun (p1, p2) -> max p1 p2)
    |> List.max
```