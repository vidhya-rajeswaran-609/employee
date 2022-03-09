import React, { useState, useEffect } from "react";
import "./employee.css";
import Avatar from "react-avatar";
import Grid from "@material-ui/core/Grid";
import MaterialTable from "material-table";
import Alert from "@material-ui/lab/Alert";
import tableIcons from "../shared/table-icons";
import validate from "../shared/validator";
import api from "../api/server";

const Employee = () => {
  const [data, setData] = useState([]);
  const [roles, setRoles] = useState([]);
  const [iserror, setIserror] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const columns = [
    { title: "id", field: "employeeId", hidden: true },
    {
      title: "Avatar",
      render: (rowData) => (
        <Avatar
          maxInitials={1}
          size={40}
          round={true}
          name={rowData === undefined ? " " : rowData.firstName}
        />
      ),
    },
    { title: "First name", field: "firstName" },
    { title: "Last name", field: "lastName" },
    { title: "Role ", field: "roleId", lookup: { ...roles } },
    { title: "Employee Number ", field: "employeeNumber" },
    { title: "Extension", field: "extension" },
    {
      title: "Date Joined",
      field: "dateJoined",
      type: "date",
      dateSetting: { locale: "en-GB" },
    },
  ];

  useEffect(() => {
    api
      .get("/employee")
      .then((res) => {
        setData(res.data);
      })
      .catch((error) => {
        console.log("Error");
      });
  }, []);

  useEffect(() => {
    api
      .get("/company")
      .then((res) => {
        const rolesData = res.data.reduce(function (acc, cur, i) {
          acc[cur.roleId] = cur.roleName;
          return acc;
        }, {});
        setRoles(rolesData);
      })
      .catch((error) => {
        console.log("Error");
      });
  }, []);

  const handleRowUpdate = (newData, oldData, resolve) => {
    const errors = validate(newData);
    newData.roleId = Number(newData.roleId);
    newData.extension = Number(newData.extension);

    if (errors.length < 1) {
      api
        .put("/employee/" + newData.employeeId, newData)
        .then(() => {
          const foundIndex = data.findIndex(
            (employee) => employee.employeeId === oldData.employeeId
          );
          data[foundIndex] = newData;
          setData([...data]);
          resolve();
          setIserror(false);
          setErrorMessages([]);
        })
        .catch((error) => {
          setErrorMessages(["Update failed! Server error"]);
          setIserror(true);
          resolve();
        });
    } else {
      setErrorMessages(errors);
      setIserror(true);
      resolve();
    }
  };

  const handleRowAdd = (newData, resolve) => {
    const errors = validate(newData);
    if (errors.length < 1) {
      api
        .post("/employee", newData)
        .then((res) => {
          const dataToAdd = [...data];
          dataToAdd.push(newData);
          setData(dataToAdd);
          resolve();
          setErrorMessages([]);
          setIserror(false);
        })
        .catch((error) => {
          setErrorMessages(["Cannot add data. Server error!"]);
          setIserror(true);
          resolve();
          console.log("error", error);
        });
    } else {
      setErrorMessages(errors);
      setIserror(true);
      resolve();
    }
  };

  const handleRowDelete = (oldData, resolve) => {
    api
      .delete("/employee/" + oldData.employeeId)
      .then((res) => {
        const newData = data.filter(
          (employee) => employee.employeeId !== oldData.employeeId
        );
        setData([...newData]);
        resolve();
      })
      .catch((error) => {
        setErrorMessages(["Delete failed! Server error"]);
        setIserror(true);
        resolve();
      });
  };

  return (
    <div className="App">
      <Grid container spacing={1}>
        <Grid item xs={2}></Grid>
        <Grid item xs={9}>
          <div>
            {iserror && (
              <Alert severity="error">
                {errorMessages.map((msg, i) => {
                  return <div key={i}>{msg}</div>;
                })}
              </Alert>
            )}
          </div>
          <MaterialTable
            title="Employee"
            columns={columns}
            data={data}
            icons={tableIcons}
            editable={{
              onRowUpdate: (newData, oldData) =>
                new Promise((resolve) => {
                  handleRowUpdate(newData, oldData, resolve);
                }),
              onRowAdd: (newData) =>
                new Promise((resolve) => {
                  handleRowAdd(newData, resolve);
                }),
              onRowDelete: (oldData) =>
                new Promise((resolve) => {
                  handleRowDelete(oldData, resolve);
                }),
            }}
          />
        </Grid>
        <Grid item xs={3}></Grid>
      </Grid>
    </div>
  );
};

export default Employee;
