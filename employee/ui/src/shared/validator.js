const validate = (newData) => {
  let errorList = [];
  if (newData.firstName === "" || newData.firstName === undefined) {
    errorList.push("Please enter First name");
  }
  if (newData.lastName === "" || newData.lastName === undefined) {
    errorList.push("Please enter Last name");
  }
  if (newData.employeeNumber === undefined || newData.employeeNumber === "" ) {
    errorList.push("Employee number is invalid");
  }
  if ( newData.extension === undefined || newData.extension === "" ) {
    errorList.push("Extension is invalid");
  }
  if ( newData.roleId === undefined || newData.roleId === "") {
    errorList.push("Role is invalid");
  }
  return errorList;
};

export default validate;
