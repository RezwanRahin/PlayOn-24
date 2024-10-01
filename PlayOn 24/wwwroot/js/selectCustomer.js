const getCustomers = async () => {
    try {
        let response = await fetch('/Customer/GetAllCustomers');

        if (response.ok) {
            let data = await response.json();
            // console.log(data);
            return data;
        } else {
            console.log('Error fetching data:', response.statusText);
        }
    } catch (err) {
        console.log('An error occurred:', err);
    }
};

const createDropdown = async () => {
    const customers = await getCustomers();

    // Select element
    let customersSelectList = document.createElement('select');
    $(customersSelectList).addClass('form-select');

    // Select options
    let option = document.createElement('option');
    option.value = 0;
    option.textContent = 'All Customers';
    $(option).addClass('form-select');
    // option.disabled = true;
    customersSelectList.appendChild(option);

    customers.forEach(c => {
        let option = document.createElement('option');
        $(option).addClass('form-select');
        option.value = c.id;
        option.textContent = c.name;
        customersSelectList.appendChild(option);
    });

    return customersSelectList;
};

const getOption = () => {
    // Customer select element
    let customerSelect = document.querySelector('select');
    let selectedId = customerSelect.value;
    let customerID = $("#CustomerId");
    customerID.val('');

    if (selectedId != "") {
        // assign to CustomerId
        customerID.val(selectedId)
        console.log(selectedId);
    }
};

const main = async () => {
    let customerSelectElement = await createDropdown();
    $("#customerDiv").prepend(customerSelectElement);

    $(customerSelectElement).change(getOption);
};

main();