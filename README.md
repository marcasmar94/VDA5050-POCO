Here’s a draft for your `README.md` file for the `main` branch:

---

# VDA5050 POCO Models

This repository provides plain C# models for the different versions of the VDA5050 standard. The structure of the repository is designed to allow easy access and management of models for each version of the standard.

## Repository Structure

- **`main` Branch**: 
  - Contains only the JSON schemas for all VDA5050 versions. 
  - Serves as the central location for maintaining schema definitions and acts as a reference for the entire repository.
  
- **Version-Specific Branches**:
  - Each VDA5050 version has its own branch (e.g., `v2.0.0`, `v2.1.0`).
  - These branches contain only the C# models for their respective version of VDA5050.
  - Allows for version isolation and independent downloads.

## Releases

- Each version branch has a corresponding GitHub **release** or **tag**.
- You can download the models for a specific version from the [Releases](https://github.com/marcasmar94/VDA5050-POCO/releases) page.

## Why This Structure?

This structure ensures:
- **Simplicity**: Developers can download models for a specific version without mixing them with other versions.
- **Flexibility**: Contributions and updates for new versions can be made independently of existing versions.
- **Transparency**: The `main` branch provides clear visibility into the different schemas and their evolution.

## Contributing

We welcome contributions to the repository. If you'd like to:
- Add models for a new version of VDA5050, please create a new branch named after the version and submit your changes via a pull request.
- Fix or improve existing models, target the specific branch for the version you're updating.

## Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/marcasmar94/VDA5050-POCO.git
   ```
2. Checkout the branch corresponding to the version you need:
   ```bash
   git checkout v2.0.0
   ```
3. Use the C# models in your project.

## License

This repository is licensed under the [MIT License](LICENSE).
