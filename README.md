# FFFP - Fucking File Fetcher Protocol

This abselute stupid shitty protocol is made for transfering data between 2 processes, it was made to accomidate a abselutely fucking stupid requirement in a semester project

## Simple protocol flow
```mermaid
  sequenceDiagram
    participant B as Process B
    participant FS as Filesystem
    participant A as Process A

    B->>FS: Saves request file to ProcessA/Requests
    Note left of B: Starts waiting for event<br/>in ProcessA/Export
    
    FS-->>A: Event Invoked: New file in ProcessA/Requests
    A->>FS: Reads request file
    A->>A: Deserializes and interprets request
    
    A->>FS: Saves response file to ProcessA/Export
    
    FS-->>B: Event Invoked: New file in ProcessA/Export
    B->>FS: Reads response file from ProcessA/Export
```
