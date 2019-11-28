#include <iostream>

using namespace std;

int val = 1;
int val2 = 2;
int* valPtr = &val;
int& valRef = val;

void printVals() {
  std::cout << "Values:" << std::endl;
  std::cout << "val: " << val << " val2: " << val2 << " valPtr: " << *valPtr << " valRef: " << valRef << std::endl;
  std::cout << "Address:" << std::endl;
  std::cout << "val: " << &val << " val2: " << &val2 << " valPtr: " << valPtr << " valRef: " << &valRef << std::endl;
}

int main() {
  printVals();
  valPtr = &val2;
  printVals();
  *valPtr = 3;
  printVals();
  valRef = 4;
  printVals();
  return 0;
}