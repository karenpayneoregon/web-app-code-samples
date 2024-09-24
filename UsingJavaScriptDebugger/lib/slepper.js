const sleep = (ms) =>
    new Promise(resolve => setTimeout(resolve, ms));

const greet = async (waitTime) => {
    console.log('I will be with you shortly');
    await sleep(waitTime);
    console.log('Hello there!');
};

function sleeper(ms) {
     return new Promise(resolve => setTimeout(resolve, ms));
}

