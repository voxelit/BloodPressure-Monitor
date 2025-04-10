const apiUrl = "http://localhost:XXXX/api/Measurements" //change when you run server

async function fetchMeasurements() {
    const response = await fetch(apiUrl);
    const measurements = await response.json();
    console.log(measurements);

    const measurementsList = document.getElementById("measurements-list");
    measurementsList.innerHTML = '';

    measurements.forEach(measurement => {
        const li = document.createElement('li');
        li.textContent = `${measurement.date} - Systolic: ${measurement.systolic} - Diastolic: ${measurement.diastolic} - Condition: ${measurement.diagnosis}`
        measurementsList.appendChild(li);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = "Delete";
        deleteButton.onclick = () => deleteMeasurement(measurement.date);
        li.appendChild(deleteButton);

    })
}

async function addMeasurement()
{
    const date = document.getElementById("dayOfMeasurement").value;
    const systolic = document.getElementById("sysValue").value;
    const diastolic = document.getElementById("diaValue").value;
    const condition = 1;
    const measurement = {date, systolic: parseInt(systolic), diastolic: parseInt(diastolic), condition};
    console.log(measurement);
    await fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'Application/json'
        },
        body: JSON.stringify(measurement)
    });
    fetchMeasurements();
}

async function deleteMeasurement(date)
{
    await fetch(`${apiUrl}/${date}`, {
        method: 'DELETE'
    });
    fetchMeasurements();
}

window.onload = fetchMeasurements();
