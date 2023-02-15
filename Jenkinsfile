pipeline {
    agent any
    
    triggers {
        githubPush()
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                bat 'docker-compose -f C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml up --build -d sql_server'
                bat 'ping 127.0.0.1 -n 41 > nul'
                bat 'docker-compose -f C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml up --build -d frontend'
                bat 'docker-compose -f C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml up --build -d backend'
            }
        }
    }

    post {
        success {
            bat 'echo "success"'
        }
        failure {
            bat 'echo "Build failed"'
        }
    }
}
