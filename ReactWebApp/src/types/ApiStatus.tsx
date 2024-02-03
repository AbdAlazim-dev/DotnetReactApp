type Args = {
    status : 'success' | 'error' | 'idle' | 'loading',
}

const ApiStatus =  ({status} : Args) => {
    switch (status) {
        case  "error" : 
            return <div>Error from the data in the backend</div>
        case "idle" : 
            return <div>Idle</div>
        case "loading" :
            return <div className="d-flex justify-content-center">
                        <div className="spinner-border" role="status">
                        </div>
                    </div>
        default : 
        throw new Error("Unknown Api state");
    }
}

export default ApiStatus;